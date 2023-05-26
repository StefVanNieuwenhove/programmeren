using Feest.Domain.DTO;
using Feest.Domain.Exceptions;
using Feest.Domain.Interface;
using Feest.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feest.Domain.Managers {
    public class DayPlanManager {
        private readonly IDayPlanRepository _repository;

        public DayPlanManager(IDayPlanRepository dayPlanRepo) {
            this._repository = dayPlanRepo;
        }

        public List<DayPlanDTO> GetDayPlanOfUser(int userId) {
            try {
                List<EventDTO> events = new();
                return _repository.GetDayPlanOfUser(userId)
                    .Select(x => new DayPlanDTO(x.Id, x.Date, new UserDTO(x.User.Id, x.User.FirstName, x.User.LastName, x.User.Budget), null, x.Price))
                    .ToList();
            } catch (DayPlanException ex) {
                throw new DayPlanException(ex.Message);
            }
        }

        public int CreateDayPlan(UserDTO userDTO, DateTime date) {
            try {
                // dayplan met id, date, user, price ==> events == null
                // controle
                    // domeinregel 4: user mag 1 dagplan aanmaken per dag
                    // ==> bool ExistDayPlan(userId, date)
                    bool result = _repository.ExistDayPlan(userDTO.Id, date);
                    // ==> if false then createdayplan
                    // ==> if true throw exception with ex.message = domeinregel 4
                    if (!result) {
                    User user = new(userDTO.Id, userDTO.FirstName, userDTO.LastName, userDTO.Budget);
                    return _repository.CreateDayPlan(user, date);
                } else {
                    throw new DayPlanException($"The user has already created a dayplan for this day ({date})");
                }


                
            } catch (DayPlanException ex) {
                throw new DayPlanException(ex.Message);
            }
        }

        public List<string> AddEventToDayPlan(int dayPlanId, EventDTO dto, UserDTO user, DateTime dayPlanDate) {
            try {
                
                // domeinregel 1: Hetzelfde event kan op dayplan niet meerdere keren voorkomen
                // bool ExistEventDayPlan(dayplanId, eventId)
                // if true exception 
                bool existEvent = ExistEventDayPlan(dayPlanId, dto.Id);
                if (existEvent) {
                    throw new DayPlanException("The selected event is already added to the current dayplan.");
                }

                // domeinregel 2: event mag niet overlappen met reeds actieve events
                // bool DoesEventOverlay(dayplanId, userId)
                bool eventOverlay = DoesEventOverlay(dayPlanId, user.Id, dto);
                if (eventOverlay) {
                    throw new DayPlanException("The event overlaps with an other event");
                }

                // domeinregel 3: event moet plaatsvinden op datum van dayplan
                // bool SameDateOdDayPlanAndEvent(eventId, dayplanDate)
                bool sameDate = SameDateOdDayPlanAndEvent(dto, dayPlanDate);
                if (sameDate) {
                    throw new DayPlanException("The event doesn't take place on the date of the choosen dayplan date!");
                }
                
                // domeinregel 6: kostprijs van events mag totaal bedrag user niet overschrijden
                // bool CalculateTotalePrice(int dayPlanId, int userId, EventDTO dto)
                bool crossedTotalBudget = CalculateTotalePrice(dayPlanId, user, dto);
                if (crossedTotalBudget) {
                    throw new DayPlanException("The budget of the user is crossed!");
                }

                return _repository.AddEventToDayPlanUser(dayPlanId, user.Id, dto.Id).Select(x => $"{x.Title}\n\tStart: {x.StartDate}\n\tEnd: {x.EndDate}").ToList();
            } catch (DayPlanException ex) {
                throw new DayPlanException(ex.Message);
            }
        }

        private bool ExistEventDayPlan(int dayPlanId, int eventId) {
            try {
                return _repository.ExistEventDayPlan(dayPlanId, eventId);
            } catch (DayPlanException ex) {
                throw new DayPlanException(ex.Message);
            }
        }

        private bool DoesEventOverlay(int dayPlanId, int userId, EventDTO dto) {
            try {
                bool result = false;
                List<EventDTO> events = _repository.GetEventsOfDatPlanUser(dayPlanId, userId).Select(x => new EventDTO(x.Id, x.Title, x.StartDate, x.EndDate, x.Price, x.Description)).ToList();
                events.ForEach(x => {
                    if (x.StartDate.Hour <= dto.StartDate.Hour && x.EndDate.Hour <= dto.EndDate.Hour) {
                        result = true;
                    }
                    result = false;
                });
                return result;                    
            } catch (DayPlanException ex) {
                throw new DayPlanException(ex.Message);
            }
        }

        private bool SameDateOdDayPlanAndEvent(EventDTO dto, DateTime dayPlanDate) {
            try {
                if (dto.StartDate.Equals(dayPlanDate)) {
                    return true;
                } return false;
            } catch (DayPlanException ex) {
                throw new DayPlanException(ex.Message);
            }
        }

        private bool CalculateTotalePrice(int dayPlanId, UserDTO user, EventDTO dto) {
            try {
                decimal priceOfEvents = _repository.GetEventsOfDatPlanUser(dayPlanId, user.Id).Select(x => x.Price).Sum();
                if (priceOfEvents + dto.Price > user.Budget) {
                    return true;
                } return false;
            } catch (DayPlanException ex) {
                throw new DayPlanException(ex.Message);
            }

        }
    }
}

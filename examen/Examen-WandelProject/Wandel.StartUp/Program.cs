// See https://aka.ms/new-console-template for more information

using Domein.Wandel;
using Presentation.Wandel;
using Wandel.Persistence;

TochtMapper tochMapper = new TochtMapper();
DomeinManager manager = new DomeinManager(tochMapper);
WandelApp app = new WandelApp(manager);
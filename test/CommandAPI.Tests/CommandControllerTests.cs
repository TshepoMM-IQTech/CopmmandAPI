using System;
using Xunit;
using CommandAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using CommandAPI.Data;
using Moq;
using System.Collections.Generic;
using CommandAPI.Models;
using CommandAPI.Profiles;
using AutoMapper;

namespace CommandAPI.Tests
{
    public class CommandsControllerTests
    {
        [Fact]
        public void GetCommandItems_Returns200OK_WhenDBIsEmpty()
        {
            //Arrange
            var mockRepo = new Mock<ICommandAPIRepo>();                             
            mockRepo.Setup(repo =>                                                  
            repo.GetAllCommands()).Returns(GetCommands(0));                         


            var realProfile = new CommandsProfile();
            var configuration = new MapperConfiguration(cfg =>
            cfg.AddProfile(realProfile));
            IMapper mapper = new Mapper(configuration);
            var controller = new CommandsController(mockRepo.Object, mapper);
        }

        private List<Command> GetCommands(int num)                                  //5
        {
            var commands = new List<Command>();
            if (num > 0)
            {
                commands.Add(new Command
                {
                    Id = 0,
                    HowTo = "How to generate a migration",
                    CommandLine = "dotnet ef migrations add <Name of Migration>",
                    Platform = ".Net Core EF"
                });
            }
            return commands;
        }
    }
}
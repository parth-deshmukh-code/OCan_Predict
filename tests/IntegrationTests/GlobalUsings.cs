global using System.Net;
global using System.Net.Http.Headers;
global using System.Linq.Expressions;
global using NUnit.Framework;
global using FluentAssertions;
global using Microsoft.AspNetCore.Mvc.Testing;
global using Microsoft.EntityFrameworkCore;
global using DotEnv.Core;
global using MySqlConnector;
global using Respawn;

global using DentallApp.Infrastructure;
global using DentallApp.Infrastructure.Persistence;
global using DentallApp.Shared.Interfaces;
global using DentallApp.Shared.Constants;
global using DentallApp.Shared.Entities;
global using DentallApp.Shared.Resources.Genders;
global using DentallApp.Shared.Resources.Kinships;
global using DentallApp.Shared.Resources.Statuses;
global using DentallApp.Shared.Models.Claims;

global using DentallApp.Core.Persons.UseCases;

global using IntegrationTests.Common;
global using IntegrationTests.Common.Seeds;

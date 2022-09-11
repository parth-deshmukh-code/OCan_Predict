﻿namespace DentallApp.Features.Persons;

public interface IPersonRepository : IRepository<Person>
{
    Task<IEnumerable<PersonGetDto>> GetPersonsAsync(string valueToSearch);
}

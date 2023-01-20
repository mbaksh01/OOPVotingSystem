using OOPVotingSystem.DAL;
using OOPVotingSystem.Models;
using OOPVotingSystem.Repositories.Abstractions;
using System.Linq.Expressions;

namespace OOPVotingSystem.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly PersonContext _personContext;
    private readonly VoteContext _voteContext;

    public PersonRepository(PersonContext context, VoteContext voteContext)
    {
        _personContext = context;
        _voteContext = voteContext;
    }

    public void CastVote(Vote vote)
    {
        _ = _voteContext.Votes.Add(vote);

        _ = _voteContext.SaveChanges();
    }
    
    public async Task CastVoteAsync(Vote vote)
    {
        _ = await _voteContext.Votes.AddAsync(vote);

        _ = await _voteContext.SaveChangesAsync();
    }
    
    public async Task<Person> CreateAsync(Person entity)
    {
        entity.Id = Guid.NewGuid().ToString();

        _ = await _personContext.People.AddAsync(entity);

        _ = await _personContext.SaveChangesAsync();

        return entity;
    }
    
    public async Task DeleteAsync(string id)
    {
        Person person = await GetPersonAsync(id);

        _ = _personContext.People.Remove(person);

        _ = await _personContext.SaveChangesAsync();
    }

    public Task<IEnumerable<Person>> GetAllAsync() => Task.FromResult(_personContext.People.AsEnumerable());

    public Task<Person> GetByIdAsync(string id) => GetPersonAsync(id);

    public bool HasAcceptedTerms(string id)
    {
        Person person = GetPerson(id);

        return person.AcceptedTerms;
    }
    
    public async Task<bool> HasAcceptedTermsAsync(string id)
    {
        Person person = await GetPersonAsync(id);

        return person.AcceptedTerms;
    }
    
    public bool IsVerified(string id)
    {
        Person person = GetPerson(id);

        return person.Verified;
    }
    
    public async Task<bool> IsVerifiedAsync(string id)
    {
        Person person = await GetPersonAsync(id);

        return person.Verified;
    }
    
    public void RegisterToVote(string id)
    {
        Person person = GetPerson(id);

        if (!person.AcceptedTerms)
        {
            throw new InvalidOperationException(
                "A person can not register to vote if they have not accepted the terms and conditions."
            );
        }

        if (!person.Verified)
        {
            throw new InvalidOperationException(
                "A person can not register to vote if they have not are not verified."
            );
        }
    }
    
    public async Task RegisterToVoteAsync(string id)
    {
        Person person = await GetPersonAsync(id);

        if (!person.AcceptedTerms)
        {
            throw new InvalidOperationException(
                "A person can not register to vote if they have not accepted the terms and conditions."
            );
        }

        if (!person.Verified)
        {
            throw new InvalidOperationException(
                "A person can not register to vote if they have not are not verified."
            );
        }
    }
    
    public Task UpdateAsync(string id, Person entity)
    {
        _ = _personContext.People.Update(entity);

        return _personContext.SaveChangesAsync();
    }

    private Person GetPerson(string id)
    {
        Person? person = _personContext.People.Find(id);

        if (person is null)
        {
            throw new ArgumentException(
                "The primary key provided was not associated with any person.",
                nameof(id)
            );
        }

        return person;
    }

    private async Task<Person> GetPersonAsync(string id)
    {
        Person? person = await _personContext.People.FindAsync(id);

        if (person is null)
        {
            throw new ArgumentException(
                "The primary key provided was not associated with any person.",
                nameof(id)
            );
        }

        return person;
    }
}

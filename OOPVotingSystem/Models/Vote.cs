namespace OOPVotingSystem.Models;

public class Vote
{
    public Vote(string electionId, string personId)
    {
        Id = Guid.NewGuid().ToString();
        ElectionId = electionId;
        PersonId = personId;
    }

    public Vote(string candidateId, string electionId, string personId)
    {
        Id = Guid.NewGuid().ToString();
        CandidateId = candidateId;
        ElectionId = electionId;
        PersonId = personId;
    }

    public string Id { get; set; }

    public string? CandidateId { get; set; }

    public string ElectionId { get; set; }

    public string PersonId { get; set; }

    public virtual Candidate? Candidate { get; set; } = default!;

    public virtual Election Election { get; set; } = default!;

    public virtual Person Person { get; set; } = default!;
}

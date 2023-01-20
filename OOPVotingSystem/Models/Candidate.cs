namespace OOPVotingSystem.Models;

public class Candidate : Person
{
    public Candidate(string electionId, string partyId)
    {
        CandidateId = Guid.NewGuid().ToString();
        ElectionId = electionId;
        PartyId = partyId;
    }

    public string CandidateId { get; set; }
    
    public string ElectionId { get; set; }
    
    public string PartyId { get; set; }

    public void LeaveParty()
    {
        throw new NotImplementedException();
    }
}

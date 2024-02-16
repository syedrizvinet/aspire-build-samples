﻿namespace OrleansVoting;

public interface IPollGrain : IGrainWithStringKey
{
    Task CreatePoll(PollState initialState);
    Task<PollState> GetCurrentResults();
    Task<PollState> AddVote(int optionId);
    Task StartWatching(IPollWatcher watcher);
    Task StopWatching(IPollWatcher watcher);
}

[GenerateSerializer]
public class PollState
{
    [Id(0)] public required string Question { get; init; }
    [Id(1)] public required List<(string Option, int Votes)> Options { get; init; }
}

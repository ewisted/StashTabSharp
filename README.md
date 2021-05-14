[![CircleCI](https://circleci.com/gh/ewisted/StashTabSharp/tree/master.svg?style=svg&circle-token=a30744a38daa14c3a400cff44f6e9dc90f844648)](https://circleci.com/gh/ewisted/StashTabSharp)
[![Nuget](https://buildstats.info/nuget/StashTabSharp)](https://www.nuget.org/packages/StashTabSharp/)

# StashTabSharp
A C# client for the Path of Exile Stash Tab API

## Overview
This project targets .Net Standard 2.1 in order to leverage IAsyncEnumerable (covered further below), which is a perfect use case for the Path of Exile stash tab API. Earlier version support is planned, as there are other methods exposed in the client that would work in earlier versions of .Net but IAsyncEnumerable method would be made unavailable with compiler directives. Documentation on all methods exposed by this client will be made available soon.

## Sample with IAsyncEnumerable
The following snippet shows how to use IAsyncEnumerable to asynchronously retrieve data from the stash tab API for ten seconds, after which it uses a CancellationTokenSource to close the stream.

```c#
StashTabClient client = new StashTabClient();
CancellationTokenSource tokenSource = new CancellationTokenSource();
tokenSource.CancelAfter(TimeSpan.FromSeconds(10));

await foreach (StashData stashData in client.GetAsyncDataStream().WithCancellation(tokenSource.Token))
{
    // Do something with the stash data
}
```

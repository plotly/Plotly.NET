module Plotly.NET.ImageExport.AsyncHelper

open System.Threading
open System.Threading.Tasks

(*

This is a workaround to avoid deadlocks

https://medium.com/rubrikkgroup/understanding-async-avoiding-deadlocks-e41f8f2c6f5d
 
TL;DR in many cases, for example, GUI apps, SynchronizationContext
is overriden to *post* the executing code on the initial (UI) thread. For example,
consider this code
 
public async Task OnClick1()
{
    var chart = ...;
    var base64 = ImageExport.toBase64PNGStringAsync()(chart).Result;
    myButton.Text = base64;
}

Here we have an async method. Normally you should use await and not use .Result, but
assume for some reason the sync version is used. What happens under the hood is,

public async Task OnClick1()
{
    var chart = ...;
    var task = ImageExport.toBase64PNGStringAsync()(chart);
    task.ContinueWith(() =>
        UIThread.Schedule(() =>
            myButton.Text = Result;
        )
    );
    task.Wait();
}

(this is pseudo-code)

So basically, we set the task to wait until it finishes. However, part of it being
finished is to actually execute the code with button.Text = .... The waiting happens
on the UI thread, exactly on the same thread as where we're waiting for it to do
another job!

That's not the only place we potentially deadlock by using fake synchronous functions.
The reason why it happens, is because frameworks (or actually anyone) override
SynchronizationContext. In GUI and game development it's very useful to keep UI logic
on one thread. But our rendering does not ever callback to it, we're independent of
where the logic actually happens.

That's why what we do is we set the synchronization context to null, do the job, and
then restore it. It is a workaround, because it doesn't have to work everywhere and
independently. But it will work for most cases.

When will it also break? For example, if we decide to take in some callback as a para-
meter, which potentially accesses the UI thread (or whatever). In Unity, for instance,
you can only access Unity API from the main thread. So our fake synchronous function
will crash in the end, because due to the overriden (by us) sync context, the callback
will be executed in some random thread (as opposed to being posted back to the UI one).

However, our solution should work in most cases.

Credit to [@DaZombieKiller](https://github.com/DaZombieKiller) for helping.
 
*)

let runSync job input =
    let current = SynchronizationContext.Current
    SynchronizationContext.SetSynchronizationContext null

    try
        job input
    finally
        SynchronizationContext.SetSynchronizationContext current

let taskSync (task: Task<'a>) = task |> runSync (fun t -> t.Result)

let taskSyncUnit (task: Task) = task |> runSync (fun t -> t.Wait())

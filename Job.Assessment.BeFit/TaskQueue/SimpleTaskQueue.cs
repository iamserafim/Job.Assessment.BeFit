using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Task = Job.Assessment.BeFit.TaskProcessor.Task;

namespace Job.Assessment.BeFit.TaskQueue;

public class SimpleTaskQueue
{
    private readonly ConcurrentQueue<Task> taskQueue = new ();
    private volatile bool isProcessing = false;

    public void AddTask(Task taskFunc)
    {

    }


    public async System.Threading.Tasks.Task WaitForCompletion()
    {

    }
}

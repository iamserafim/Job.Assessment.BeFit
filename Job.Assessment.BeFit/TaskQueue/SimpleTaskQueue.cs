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
        if (taskFunc == null)
        {
            throw new ArgumentNullException(nameof(taskFunc), "Task function cannot be null");
        }

        taskQueue.Enqueue(taskFunc);

        if (!isProcessing)
        {
            StartProcessing();
        }
    }

    private async void StartProcessing()
    {
        if (!isProcessing)
        {
            isProcessing = true;

            await Task.Run(async () =>
            {
                while (taskQueue.TryDequeue(out var taskFunc))
                {
                    try
                    {
                        await taskFunc();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Task execution failed: {ex.Message}");
                    }
                }

                isProcessing = false;
            });
        }
    }

    public async Task WaitForCompletion()
    {
        while (isProcessing || !taskQueue.IsEmpty)
        {
            await Task.Delay(10); // Подождем немного и проверим снова.
        }
    }
}

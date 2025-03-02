// O(N) where N is the number of elements in the tasks array time complexity
public int LeastInterval(char[] tasks, int n)
{
    int time = 0;

    Dictionary<char, int> uniqueTasks = new Dictionary<char, int> ();
    PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>(new PriorityComparator());
    Queue<(int, int)> queue = new Queue<(int, int)>();

    for (int i = 0; i < tasks.Length; i++) {
        if (uniqueTasks.ContainsKey(tasks[i]))
        {
            uniqueTasks[tasks[i]]++;
        }
        else
        {
            uniqueTasks.Add(tasks[i], 1);
        }
    }


    foreach (var task in uniqueTasks) {
        maxHeap.Enqueue(task.Value, task.Value);
    }

    while (maxHeap.Count > 0 || queue.Count > 0) {
        if (queue.Count > 0 && queue.Peek().Item2 == time) { 
            var e = queue.Dequeue();
            maxHeap.Enqueue(e.Item1, e.Item1);
        }
        time++;
        if(maxHeap.Count > 0)
        {
            var elem = maxHeap.Dequeue();
            if(elem > 1)
            {
                queue.Enqueue((elem - 1, time + n));
            }
        }
    }

    return time;
}

public class PriorityComparator : IComparer<int>
{
    public int Compare(int x, int y)
    {
        return y - x;
    }
}
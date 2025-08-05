public class MinHeap
{
    private int size = 0;
    private int maxCapacity = 10;

    private int[] myValues = new int[10];

    private int GetLeftChildIndex(int index)
    {
        return 2 * index + 1;
    }

    private int GetRightChildIndex(int index) 
    { 
        return 2 * index + 2; 
    }

    private int GetParentIndex(int index)
    {
        return (index - 1)  / 2;
    }

    private bool HasLeftChild(int index)
    {
        return GetLeftChildIndex(index) < size;
    }

    private bool HasRightChild(int index) 
    {
        return GetRightChildIndex(index) < size;
    }

    private bool HasParent(int index)
    {
        return GetParentIndex(index) >= 0;
    }

    private int GetLeftChild(int index)
    {
        return myValues[GetLeftChildIndex(index)];
    }

    private int GetRightChild(int index)
    {
        return myValues[GetRightChildIndex(index)];
    }

    private int GetParent(int index)
    {
        return myValues[GetParentIndex(index)];
    }

    private void Swap(int i, int j)
    {
        int temp = myValues[i];
        myValues[i] = myValues[j];
        myValues[j] = temp;
    }

    private void EnsureCapacity()
    {
        if (size == maxCapacity) 
        {
            var newArray = new int[maxCapacity * 2];
            Array.Copy(myValues, newArray, myValues.Length);
        }
    }

    public int Peek()
    {
        if(size == 0)
        {
            throw new InvalidOperationException();
        }
        return myValues[0];
    }

    public int Poll()
    {
        if(size == 0)
        {
            throw new InvalidOperationException();
        }

        int item = myValues[0];
        myValues[0] = myValues[size - 1];
        myValues[size - 1] = 0;
        size--;
        HeapifyDown();
        return item;
    }

    public void Add(int value)
    {
        EnsureCapacity();
        myValues[size] = value;
        size++;
        HeapifyUp();
    }

    private void HeapifyUp()
    {
        int index = size - 1;
        while(HasParent(index) && GetParent(index) > myValues[index])
        {
            Swap(index, GetParentIndex(index));
            index = GetParentIndex(index);
        }
    }

    private void HeapifyDown()
    {
        int index = 0;

        while(HasLeftChild(index))
        {
            int smallChildIndex = GetLeftChildIndex(index);
            if(HasRightChild(index) && GetRightChild(index) < GetLeftChild(index))
            {
                smallChildIndex = GetRightChildIndex(index);
            }

            if (myValues[index] < myValues[smallChildIndex])
            {
                break;
            }
            else
            {
                Swap(index, smallChildIndex);
                index = smallChildIndex;
            }
        }
    }
}
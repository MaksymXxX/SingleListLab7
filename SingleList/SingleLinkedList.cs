namespace SingleList
{
    public class Node
    {
        public short Data { get; set; }

        public Node? Next { get; set; }

        public Node(short data)
        {
            Data = data;
            Next = null;
        }
    }

    public class SingleLinkedList
    {
        private Node? head;

        public SingleLinkedList()
        {
            head = null;
        }

        public void AddAfterFirst(short data)
        {
            Node newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                newNode.Next = head.Next;
                head.Next = newNode;
            }
        }

        public Node? FindFirstGreaterThan(short value)
        {
            Node? current = head;

            while (current != null)
            {
                if (current.Data > value)
                {
                    return current;
                }

                current = current.Next;
            }

            return null;
        }

        public short SumGreaterThanAverage()
        {
            if (head == null)
            {
                return 0;
            }

            var average = GetAverageValue();

            short sum = 0;
            Node? current = head;

            while (current != null)
            {
                if (current.Data > average)
                {
                    sum += current.Data;
                }

                current = current.Next;
            }

            return sum;
        }

        public SingleLinkedList GetListLessThanAverage()
        {
            SingleLinkedList newList = new SingleLinkedList();

            if (head == null)
            {
                return newList;
            }

            double average = GetAverageValue();

            Node? current = head;
            while (current != null)
            {
                if (current.Data < average)
                {
                    newList.AddAfterFirst(current.Data);
                }
                current = current.Next;
            }

            return newList;
        }

        private double GetAverageValue()
        {
            int count = 0;
            int totalSum = 0;
            Node? current = head;

            while (current != null)
            {
                totalSum += current.Data;
                count++;
                current = current.Next;
            }

            return (double)totalSum / count;
        }

        public void RemoveElementsAfterMax()
        {
            if (head == null)
            {
                return;
            }

            Node? current = head;
            Node? maxNode = head;

            while (current != null)
            {
                if (current.Data > maxNode.Data)
                {
                    maxNode = current;
                }
                current = current.Next;
            }

            if (maxNode != null)
            {
                maxNode.Next = null;
            }
        }

        public short this[int index]
        {
            get
            {
                Node? current = head;
                int count = 0;

                while (current != null)
                {
                    if (count == index)
                    {
                        return current.Data;
                    }
                    count++;
                    current = current.Next;
                }

                throw new IndexOutOfRangeException("Index was out of range.");
            }
            set
            {
                Node? current = head;
                int count = 0;

                while (current != null)
                {
                    if (count == index)
                    {
                        current.Data = value;
                        return;
                    }
                    count++;
                    current = current.Next;
                }

                throw new IndexOutOfRangeException("Index was out of range.");
            }
        }

        public void PrintList()
        {
            Node? current = head;

            while (current != null)
            {
                Console.Write(current.Data + " ");

                current = current.Next;
            }

            Console.WriteLine();
        }
    }
}

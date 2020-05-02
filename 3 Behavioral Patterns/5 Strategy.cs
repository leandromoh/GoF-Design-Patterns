Strategy: Define a family of algorithms, encapsulate each one, and make them interchangeable. 
Strategy lets the algorithm vary independently from clients that use it.

    var studentRecords = new SortedList();

    studentRecords.Add("Samual");
    studentRecords.Add("Jimmy");
    studentRecords.Add("Sandra");
    studentRecords.Add("Vivek");
    studentRecords.Add("Anna");

    studentRecords.SetSortStrategy(new QuickSort());
    studentRecords.Sort();

    studentRecords.SetSortStrategy(new ShellSort());
    studentRecords.Sort();

    studentRecords.SetSortStrategy(new MergeSort());
    studentRecords.Sort();
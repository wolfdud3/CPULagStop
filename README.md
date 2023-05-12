# LagStop
Batch Script creator for programs to use only specific CPU cores. Creates the script used [here](https://www.wolfdud3.com/main/instruction?craftid=8) by filling in only information.

Now and then programs (especially games) are putting all their load onto the first core of the CPU, creating performance issues.
To combat this, the CPU affinities of a program can be changed avoiding the use of that specific CPU core. This can lead to the program evenly distributing the workload onto the other cores, which then can increase the overall performance or remove any lags.

This is definetly not a daily solution and should be applied carefully. Changing CPU affinities can affect the performance and stability in a negative manner if not done carefully.

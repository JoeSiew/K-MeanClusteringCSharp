# K-MeanClusteringCSharp

K-Mean Clustering - Language C#

## Problem definition
You are hired by a school to perform a grouping of students based on the mark for 24 students in order for school to design different curriculum for different group of students in subsequent semesters. You have to advise the school to group these students into
groups that you have discovered.

Table 1 below shows the simulated results for four subjects (Chemistry, History, Biology, Chinese) of 24 students in a secondary school in first semester. 

![table 1](https://github.com/JoeSiew/K-MeanClusteringCSharp/blob/master/images/table1.png)

Table 2 shows the results for another 9 students in the second semester.

![table 2](https://github.com/JoeSiew/K-MeanClusteringCSharp/blob/master/images/table2.png)

In third semester, another 4 students, as shown in Table 3, you have to group them accordingly as well by using data from table 2 and table 1.

![table 3](https://github.com/JoeSiew/K-MeanClusteringCSharp/blob/master/images/table3.png)

## Design and Results
The K-Mean Clustering was designed to be presented using both graphical user interface (GUI) and command line interface (CLI). Our GUI is responsible for plotting graph to determine suitable k-value while CLI is divided into 5 parts

#### Part 1
The first part is to show the result of our computation at finding the optimum centroid according to the k value and the Total Sum of Square Errors of each K. Our algorithm requires us to have an initial centroid set by us as follows. 

![centroid](https://github.com/JoeSiew/K-MeanClusteringCSharp/blob/master/images/centroid.png)

Subsequently, our algorithm will use table 1 to produce the following result for us to plot the graph to determine the best k value

![result 1](https://github.com/JoeSiew/K-MeanClusteringCSharp/blob/master/images/result1.png)

From the total Sum of Square Errors of each K or clusters, we are able to plot a graph to determine the most suitable k-value

![graph](https://github.com/JoeSiew/K-MeanClusteringCSharp/blob/master/images/graph.png)

#### Part 2
From the graph, the elbow is not clearly defined, however the closest point is at K = 3. Hence K = 3 is slected as Part 2 of our CLI to compute classification.
(Note: The k value can be easily changed by editing "finalK" variable in the program script

![result 2](https://github.com/JoeSiew/K-MeanClusteringCSharp/blob/master/images/result2.png)

#### Part 3 & 4
Next, in Part 3 and 4 of our CLI, we classified the data for table 2 and uses it to recalculate the centroid of k=3.

![result 3](https://github.com/JoeSiew/K-MeanClusteringCSharp/blob/master/images/result3.png)

![result 4](https://github.com/JoeSiew/K-MeanClusteringCSharp/blob/master/images/result4.png)

### Part 5
Lastly, we classified table 3 data using recalculated centroid and get the final result at part 5

![result 5](https://github.com/JoeSiew/K-MeanClusteringCSharp/blob/master/images/result5.png)

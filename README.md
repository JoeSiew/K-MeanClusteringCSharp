# K-MeanClusteringCSharp

K-Mean Clustering - Language C#

## Problem definition
You are hired by a school to perform a grouping of students based on the mark for 24 students in order for school to design different curriculum for different group of students in subsequent semesters. You have to advise the school to group these students into
groups that you have discovered.

Table 1 below shows the simulated results for four subjects (Chemistry, History, Biology, Chinese) of 24 students in a secondary school in first semester. 

Table 2 shows the results for another 9 students in the second semester.

In third semester, another 4 students, as shown in Table 3, you have to group them accordingly as well by using data from table 2 and table 1.

//table 1 img
//table 2 img
//table 3 img

## Design and Results
The K-Mean Clustering was designed to be presented using both graphical user interface (GUI) and command line interface (CLI). Our GUI is responsible for plotting graph to determine suitable k-value while CLI is divided into 5 parts

#### Part 1
The first part is to show the result of our computation at finding the optimum centroid according to the k value and the Total Sum of Square Errors of each K. Our algorithm requires us to have an initial centroid set by us as follows. 

//result1

Subsequently, our algorithm will use table 1 to produce the following result for us to plot the graph to determine the best k value

//graph

#### Part 2
From the graph, the elbow is not clearly defined, however the closest point is at K = 3. Hence K = 3 is slected as Part 2 of our CLI to compute classification.
(Note: The k value can be easily changed by editing "finalK" variable in the program script

// result 2

#### Part 3 & 4
Next, in Part 3 and 4 of our CLI, we classified the data for table 2 and uses it to recalculate the centroid of k=3.

// result 3 and 4

### Part 5
Lastly, we classified table 3 data using recalculated centroid and get the final result at part 5

// result5.png

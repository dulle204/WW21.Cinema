#User Stories:


###Must Do Functionalities:
1.	Ticket reservation
Description: Client (register user - confirmed user) should be able to reserve ticket by clicking on desired seats. When we select desired seat we proceed to payment. 
If payment is successful client have ticket and seat reserved. 
Develop backend and frontend for this functionality. If client reserves more than one seat, seats must be next to each other.
Corner Case: If we want to reserve two or more seats and we do not have them available in row one after another.
Application should inform us that we can buy tickets separately or change projection time of specific movie. 

2.	Activate/ Deactivate movie
Description: Client (administrator user – confirmed admin user) should be able to activate or deactivate movie. (current field)
Develop backend and frontend for this functionality. If movie have projections which are in future it can not be deactivated.


3.	Movie Search
Description: Client (confirmed users) should be able to search for specific movie by filtering tags.
Tags can be unlimited, like (Actor, Year, Title….)
Develop backend and frontend for this functionality.

4.	Filter Projections
Description: Client (confirmed users) should be able to filter by Cinema, Auditorium, Movie, Specific Time Span.
Develop backend and frontend for this functionality.

5.	Unit Tests
Description: Cover controllers and services with unit tests.

6.	Movie Top List
Description: Client (confirmed users) should be able to see top 10 movie according to ratings.
Develop backend and frontend for this functionality.

7.	Create Cinema
Description: Client (administrator user – confirmed admin user) should be able to create new cinema.
Develop backend and frontend for this functionality.

8.	Presenting Application
Description: Demo for application developed functionalities. Presenting which functionalities are developed.

9.	Build – Release pipeline 
Description: Investigate and present in your presentation this topic.
 
###Bonus functionalities:

1.	Cinema Bonus Points (connected to must do task 1.)
Description: Client (register user - confirmed user) should be able to collect bonus points for successful ticket purchase. 
For every successful ticket purchase, one bonus point is added for user (register user). All collected points should be visible on application.  
Develop backend and frontend for this functionality.

2.	Top list of movies (connected to must do task 6.)
Description: client (register user - confirmed user) should be able to see top list for specific year. 
If there are more movies with same rating we can rate them further if some of them have Oscar.
Develop backend and frontend for this functionality.

3.	Creation of Cinema (connected to must do task 7.)
Description: Client (administrator user – confirmed admin user) should be able to create through creation of cinema also auditorium with seats.
Develop backend and frontend for this functionality.

4.	Delete Cinema
Description: Client (administrator user – confirmed admin user) should be able to delete cinema with all his auditoriums and seats.
Develop backend and frontend for this functionality.

5.	Introduce New Role
Description: Client should be able to log as different type of users. For example: admin, super_user, user.
Develop backend and frontend for this functionality.

6.	Refactoring Client App
Description: Try to move, post, get, put and delete to single file and export them as functions. 
Develop this functionality in Client app.

7.	Add route for new user roles
Description: Add route protection for new user role.
Develop backend and frontend for this functionality.

8.	**Performance improvment**

    Description: Change some complicated queries with views. Present all improvments.



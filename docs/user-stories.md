#User Stories:


###Must Do Functionalities:
1.	**Ticket Reservation**<br/>
Description: Client (register user - confirmed user) should be able to reserve ticket by clicking on desired seats. When we select desired seat we proceed to payment.
If payment is successful client have ticket and seat reserved.<br/>
Develop backend and frontend for this functionality. If client reserves more than one seat, seats must be next to each other.
Corner Case: If we want to reserve two or more seats and we do not have them available in row one after another.
Application should inform us that we can buy tickets separately or change projection time of specific movie. 

2.	**Activate/ Deactivate Movie**<br/>
Description: Client (administrator user – confirmed admin user) should be able to activate or deactivate movie. (current field)<br/>
Develop backend and frontend for this functionality. If movie have projections which are in future it can not be deactivated.<br/>

3.	**Movie Search**<br/>
Description: Client (confirmed users) should be able to search for specific movie by filtering tags.
Tags can be unlimited, like (Actor, Year, Title….)<br/>
Develop backend and frontend for this functionality.

4.	**Filter Projections**<br/>
Description: Client (confirmed users) should be able to filter by Cinema, Auditorium, Movie, Specific Time Span.<br/>
Develop backend and frontend for this functionality.

5.	**Unit Tests**<br/>
Description: Cover controllers and services with unit tests.<br/>

6.	**Movie Top List**<br/>
Description: Client (confirmed users) should be able to see top 10 movie according to ratings.<br/>
Develop backend and frontend for this functionality.

7.	**Create Cinema**<br/>
Description: Client (administrator user – confirmed admin user) should be able to create new cinema.<br/>
Develop backend and frontend for this functionality.

8.	**Presenting Application**<br/>
Description: Demo for application developed functionalities. Presenting which functionalities are developed.<br/>

9.	**Build – Release Pipeline** <br/>
Description: Investigate and present in your presentation this topic.
 
###Bonus functionalities:

1.	**Cinema Bonus Points** - (connected to must do task 1.)<br/>
Description: Client (register user - confirmed user) should be able to collect bonus points for successful ticket purchase.
For every successful ticket purchase, one bonus point is added for user (register user). All collected points should be visible on application.<br/>
Develop backend and frontend for this functionality.

2.	**Movies Top List** - (connected to must do task 6.)<br/>
Description: client (register user - confirmed user) should be able to see top list for specific year. 
If there are more movies with same rating we can rate them further if some of them have Oscar.<br/>
Develop backend and frontend for this functionality.

3.	**Create Cinema** - (connected to must do task 7.)<br/>
Description: Client (administrator user – confirmed admin user) should be able to create through creation of cinema also auditorium with seats.<br/>
Develop backend and frontend for this functionality.

4.	**Delete Cinema**<br/>
Description: Client (administrator user – confirmed admin user) should be able to delete cinema with all his auditoriums and seats.<br/>
Develop backend and frontend for this functionality.

5.	**Introduce New Role**<br/>
Description: Client should be able to log as different type of users. For example: admin, super_user, user.<br/>
Develop backend and frontend for this functionality.

6.	**Refactoring Client App**<br/>
Description: Try to move, post, get, put and delete to single file and export them as functions. <br/>
Develop this functionality in Client app.

7.	**Add Route For New User Roles**<br/>
Description: Add route protection for new user role.<br/>
Develop backend and frontend for this functionality.

8.	**Performance Improvment**<br/>

    Description: Change some complicated queries with views. Present all improvments.<br/>


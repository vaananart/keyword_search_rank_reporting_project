# Instruction/Execution Steps: 
* Step 1: checkout from the repository
    * NOTE: If you are unzipping the zip file into a folder then you don't need checkout the source code from the repository. *GOTO* to Step 2.
* Step 2: Open Visual Studio 2019 IDE.
* Step 3: Select the solution in Sympli-Web-Search-App folder to open the projects.
    * There should be only two projects (web app + unit tests ). Please do not be alarmed.
* Step 4: Build the project.
* Step 5: Run the project.
    * this should open up the browser with Web UI and the backend running. I wired up the (ReactJS + Bootstrap) to query the backend. You should not need NodeJS to run this. 

# Extension 3:
## Performance Considerations
### Code Implementation
* Caching-like lookup is implemented for queried data that matches the search and rank keywords
    * The implementation does not automatically update the searched keywords after one hour. Instead for every queries received, the records timestamp is checked before deciding to queries the search engine.
    * This feature (Extension 1) needs to be implemented at I ended up receiving 429 Error Code for hitting their engine too often.
* Factory and Singleton Patterns are used for initial create and reuse of services.
* Async programming concepts/pattern was introduced and used to avoid future or potential blocking.
* Need to remove Ad banner from the list of result block for the search result payload. Without this cleanup, the testing result is inconsistent and breaking idempotence.
* Dependency Injection were used wire up the ServiceFactory interfaces to the Controller. Kept the DI setup to the minimum as a pattern to consider for future implementation.


## Availability Considerations
### Assumptions: We have access to run the app in AWS:
* We can deploy several images of the app on containers across continents (EU + Singapore + Australia + US) then use load balancer to perform health checks and distribute received requests to specific IP addresses.
* Instead of Load Balancer, we can use Akka.NET for direct communications via messaging between VMs where the apps are running.
    * This helps to reuse cached data between apps.
* Getting optics to telemetry via logging can help for the dev / devops teams to be proactive then reactive. In Azure, apps can be wired to App Insights to record such data and to able to plot graphs on CPU and Memory consumptions.
* Observing requested IP address to detect patterns of Denial of Service can be predicted and avoid responding or responding with warning notification.

## Reliability Considerations

* Unit Testing for code coverage is needed.
* Time-to-Time automated testing is needed to stress test the app and the infrastruture holding the app. I assume of one VM running a nubmer of various apps or a multi-tenant cloud where resources are shared, stress test can help to determine the performance.
* Better error handling is needed. Require to go back to design or drawing board to workout the state diagrams or event modeling for this.

### Dev Team
* We have to also assess our development processes to have small quality releases to mitigate risks. Frequent CI/CD releases are recommended.
* Code Reviews and pair programming are recommended for collective engagement and agreedable solutions. 
* Clean architecture design disciple is required. 
* Always Ready-for-Production quality branch is available and maintained.
* In SaaS environment where technology stack are ever changing. Migration plans are to be always accessed and ready for contingencies.
* In SaaS environment, rollback or backward compatibility support is a challenge, hence any feature, about to be implemented, requires an accessment with QA and Dev team for deployment and roll out. Database upgrade is only of those challenging component for backward compactible support and a challenge to roll back if rolled out incorrectly.
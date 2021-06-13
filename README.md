# flight-coding-test
There is system which processes air flights.
## Gridnine.FlightCodingTest
<code>Flight</code> is transportation passengers from one point to another with possible transfers. So flight can be represented as set of one or more simple relocations called <code>Segments</code>. It is atomic relocation which has two attributes: departure date and arrival date.
This part located in namespace <code>Gridnine.FlightCodingTest</code>. Also there is extensions for validation flights and getting info about them.
There are three validation rules:
1. departure date must be the same or after the current time;
2. flight does not contain segments with arrival date is earlier than departure date;
3. total ground time is less than 2 hours.

## Gridnine.FlightCodingTest.Filter
Namespace <code>Gridnine.FlightCodingTest.Filter</code> contains interface <code>IFilter</code> and three classes which implement it. There is <code>Selector</code> for operate with them.

## Gridnine.FlightCodingTest.Main
Namespace <code>Gridnine.FlightCodingTest.Main</code> is necessary only for flight output in console.

## Gridnine.FlightCodingTest.Test
Namespace <code>Gridnine.FlightCodingTest.Test</code> contains class <code>FilterTest</code>. Testing carried out by means of *xUnit*. Filters were tested separately and шт different combinations.

//var connection = new signalR.HubConnectionBuilder()
//    .withUrl("/airport")
//    .build();

//connection.on("SendStatus", airportStatus => {
//    const parsed = JSON.parse(airportStatus);
//    let arrOfLegs = parsed.AirportLegs;
//    for (let legIndex in arrOfLegs) {
//        let leg = arrOfLegs[legIndex];
//        let flight = leg.Flight;
//        if (flight) {
//            $("#name" + legIndex).text(flight.FlightName);
//            $("#passanger" + legIndex).text(flight.PassangersCount);
//        }
//    }
//});
//connection.start().catch(err => console.error(err.toString()));
//setInterval(getStatus, 2000);
//function getStatus() {
//    connection.invoke("SendStatus");
}
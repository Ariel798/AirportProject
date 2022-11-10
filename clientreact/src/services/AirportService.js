function AirportService(){
  const routeToListFromServer = "http://localhost:5176/api/Landing/getstatus";
  const getAirportStatus = () => {
      return fetch(routeToListFromServer).then(res => res.json());
  }
  return {
      getAirportStatus : getAirportStatus
  }
}
export default AirportService;

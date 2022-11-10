import { useState } from 'react';
import Airport from './Airport';
import AirportService from '../services/AirportService';

const AirportPage = () => {
  const airportService = new AirportService();
  const [airportStatus, setAirportStatus] = useState([]);
  const getAirportStatus = () =>{
      airportService.getAirportStatus().then(data => {
           let arrOfLegs = data.AirportLegs;
           setAirportStatus(arrOfLegs);
      },[]);
  }
  const activateGetStatusInterval = () =>{
      setInterval(getAirportStatus,1000);
  }

  return (
    <div>
              <div>
          <button className="buttonStyle" onClick={activateGetStatusInterval}>
            Connect
          </button>
        </div>
      <Airport processes={airportStatus || []} />
    </div>
  );
};
export default AirportPage;

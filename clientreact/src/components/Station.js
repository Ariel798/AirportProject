import React from 'react';
import Airplane from './Airplane';

function Station({ number, name, process }) {
  return (
    <div className="rectangle">
      Station:{number} {name}
      {process?.Flight ? (
        <Airplane airplane={process?.Flight.FlightName} flight={process?.Flight} landingFlight = {process.Flight.Target}/>
      ) : null}
    </div>
  );
}

export default Station;


import React from 'react';

function Airplane(props) {
  console.log(props);
  return (
    <React.Fragment>
              <div>
          <div className= {props?.landingFlight === 0 ? 'landing' : 'takeoff'}>
          <div>Flight Name: {props?.airplane}</div>
          <div>Passangers Number: {props?.flight?.PassangersCount}</div>
          <img src='../../Airplane.png' alt='' height={100}></img>
                </div>
        </div>
    </React.Fragment>
  );
}

export default Airplane;

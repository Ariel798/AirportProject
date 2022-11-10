import React from 'react';
import Station from './Station';
function Airport({ processes }) {

  return (
    <React.Fragment>
      <div className="allStations">
        <div id="stationsBox">
          <Station number={4} name={'Runway'} process={processes && processes.find(process => process.AirportLegId === 4)}/>
          <Station number={3} name={'Approach'} process={processes && processes.find(process => process.AirportLegId === 3)}/>
          <Station number={2} name={'Landing preparation'} process={processes && processes.find(process => process.AirportLegId === 2)}/>
          <Station number={1} name={'Landing request'} process={processes && processes.find(process => process.AirportLegId === 1)}/>
        </div>
        <div id="transportation">
          <Station number={5} name={'Transportation'} process={processes && processes.find(process => process.AirportLegId === 5)}/>
          <Station number={8} name={'Transportation'}process={processes && processes.find(process => process.AirportLegId === 8)}/>
        </div>
        <div id="terminal">
          <Station number={6}name={'Load/Unload'}process={processes && processes.find(process => process.AirportLegId === 6)}/>
          <Station number={7}name={'Load/Unload'} process={processes && processes.find(process => process.AirportLegId === 7)}/>
        </div>
      </div>
    </React.Fragment>
  );
}

export default Airport;

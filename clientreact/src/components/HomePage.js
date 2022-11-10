import React from 'react';
import { useNavigate  } from 'react-router-dom';

import AirportPage from './AirportPage';


function HomePage(props) {

  return (
    <div>
      <div className="menu">
        <div>
        <AirportPage></AirportPage>
        </div>
      </div>
    </div>
  );
}

export default HomePage;



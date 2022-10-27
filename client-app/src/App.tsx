import React, {useEffect, useState} from 'react';
import './App.css';
import axios from "axios";
import {Header, List} from "semantic-ui-react";


function App() {

  const [activities, setActivities] = useState([]);

  useEffect(() => {
    axios.get('http://192.168.88.254:5000/api/activities').then(res => {
      console.log(res);
      setActivities(res.data);
    })
  },[])

  return (
    <div>
      <Header as='h2' icon='users' content='Reactivities' />

      <List>
        {activities.map((act: any) => (
            <List.Item key={act.id}>
              {act.title}
            </List.Item>
        ))}
      </List>
        <ul>

        </ul>
    </div>
  );
}

export default App;

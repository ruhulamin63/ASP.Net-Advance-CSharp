import React from 'react';
import {useState} from 'react';

const Click=(props)=>{

    const[d,setD] = useState(0);

    const change=()=>{    
        setD(d+1);   
    }
    return(
        <div>
            <button onClick={change}>Click Me</button>
            <span>{d}</span>
        </div>
    )
}

export default Click;
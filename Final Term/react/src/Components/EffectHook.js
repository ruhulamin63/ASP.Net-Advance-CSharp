import React, {useState,useEffect} from 'react';


const EffectHook = ()=>{

    let [count, setCount] = useState(0);
    let [demo,setdemo] = useState(-10000);

    useEffect(()=>{
        setTimeout(() => {
            setCount((count) => count + 1);
          }, 1000);
    },[demo]);

    const change=()=>{
        setdemo(demo+1);
    }
    return (
        <div>
            <h1>This is EffectHook {count}</h1>
            <button onClick={change}>Change Demo</button>
            
        </div>
    )
}

export default EffectHook;

import React from 'react';
import {useParams} from 'react-router-dom';
const PDetails=()=>{
    const {id} = useParams();
    return (
        <div>
            <h1>This is Product details of {id}</h1>
        </div>
    )
}
export default PDetails;
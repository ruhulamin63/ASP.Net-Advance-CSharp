import React, {useState,useEffect} from 'react';
import axios from 'axios';

const Login = ()=>{
    let [token,setToken] = useState("");
    let [name,setName] = useState("");
    let [password,setPass] = useState("");


    const loginSubmit=()=>{    
        //alert(name+" "+password);
        var obj = {username:name, password:password};
        axios.post("http://localhost:8000/api/login",obj)
        .then(resp=>{
            var token = resp.data;
            var user = {userId: token.userid,access_token:token.token};
            localStorage.setItem('user',JSON.stringify(user));
            console.log(localStorage.getItem('user'));
            //console.log(resp.data);
            //setPosts(resp.data);
        }).catch(err=>{
            console.log(err);
        }); 
    }

    return(
        <div>
            <span></span>
            <form >
                <input type="text" value={name} onChange={(e)=>setName(e.target.value)}/>
                <input type="password" value={password} onChange={(e)=>setPass(e.target.value)}/>
            </form>
            <button onClick={loginSubmit}>
                Login
            </button>
        </div>
    )

}

export default Login;
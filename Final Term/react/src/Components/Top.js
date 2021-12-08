import React from 'react'
import {Link} from 'react-router-dom';

const Top=()=>{
    return(
        <div>
            <Link to="/">Home</Link> &nbsp;&nbsp;
            <Link to="/profile">Profile</Link>&nbsp;&nbsp;
            <Link to="/contact">Contact</Link>&nbsp;&nbsp;
            <Link to="/product/2">Product</Link>&nbsp;&nbsp;
            <Link to="/color">Color Change</Link>&nbsp;&nbsp;
            <Link to="/effect">EffectHook</Link>&nbsp;&nbsp;
            <Link to="/posts">Posts</Link>&nbsp;&nbsp;
            <Link to="/login">Login</Link>&nbsp;&nbsp;
            <Link to="/plist">Products</Link>&nbsp;&nbsp;
        </div>
    )
}
export default Top;
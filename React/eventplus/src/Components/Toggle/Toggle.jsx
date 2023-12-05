import React from "react";

import "./Toggle.css"
const Toggle = ({ fnManipulator = null }) => {
    return (
        <>
            <input
                type="toggle__switch-check"
                id="switch-check"
                className="toggle__switch-check" />

            <label htmlFor="switch-check" className="toggle" onClick={fnManipulator}>
                <div className="toggle__swithc"></div>
            </label>
        </>

    )
}

export default Toggle;
import React from 'react';
import "./NextEvent.css";
import {dateFormatDbToView} from "../../Utils/stringFunctions";
import { Tooltip } from 'react-tooltip';

const NextEvent = ({title,description, eventDate, idEvento}) => {
    function conectar(idEvento) {
        alert(`Chamar o recurso para conectar: ${idEvento}`)
    }
    return (
    <article className="event-card">
<swiper-container class="mySwiper" effect="cards" grab-cursor="true">
    <swiper-slide>Slide 1</swiper-slide>
    <swiper-slide>Slide 2</swiper-slide>
    <swiper-slide>Slide 3</swiper-slide>
    <swiper-slide>Slide 4</swiper-slide>
    <swiper-slide>Slide 5</swiper-slide>
    <swiper-slide>Slide 6</swiper-slide>
    <swiper-slide>Slide 7</swiper-slide>
    <swiper-slide>Slide 8</swiper-slide>
    <swiper-slide>Slide 9</swiper-slide>
  </swiper-container>

  <script src="https://cdn.jsdelivr.net/npm/swiper@11/swiper-element-bundle.min.js"></script>


    </article>
    );
};

export default NextEvent;

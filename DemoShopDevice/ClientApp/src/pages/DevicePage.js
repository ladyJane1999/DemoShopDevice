import React, { useEffect, useState, useContext} from 'react';
import {Button, Card, Col, Container, Image, Row} from "react-bootstrap";
import bigStar from '../assets/bigStar.png'
import { useParams, useHistory} from 'react-router-dom'
import { fetchOneDevice } from "../http/deviceAPI";
import { Context } from "../index";
import {
    DEVICE_ROUTE,
    BASKET_ROUTE,
    SHOP_ROUTE,
    REGISTRATION_ROUTE,
    LOGIN_ROUTE,
    ADMIN_ROUTE
} from "../utils/consts";
import { observer } from "mobx-react-lite";

const DevicePage = observer(() => {
    const { device } = useContext(Context)
    const [deviceOne, setDeviceOne] = useState([])
    const { id } = useParams()
    const history = useHistory()

    useEffect(() => {
        fetchOneDevice(id).then(data => setDeviceOne(data))
    }, [device.setBacket])

    const setProduct = () => {
        device.setBacket(deviceOne)
     
    }

    return (
        <Container className="mt-3">
            <Row>
                <Col md={4}>
                    <Image width={300} height={300} src={process.env.REACT_APP_API_URL + deviceOne.Img}/>
                </Col>
                <Col md={4}>
                    <Row className="d-flex flex-column align-items-center">
                        <h2>{deviceOne.name}</h2>
                        <div
                            className="d-flex align-items-center justify-content-center"
                            style={{background: `url(${bigStar}) no-repeat center center`, width:240, height: 240, backgroundSize: 'cover', fontSize:64}}
                        >
                            {deviceOne.rating}
                        </div>
                    </Row>
                </Col>
                <Col md={4}>
                    <Card
                        className="d-flex flex-column align-items-center justify-content-around"
                        style={{width: 300, height: 300, fontSize: 32, border: '5px solid lightgray'}}
                    >
                        <h3>От: {deviceOne.price} руб.</h3>
                        <Button onClick={setProduct} variant={"outline-dark"}>Добавить в корзину</Button>
                    </Card>
                </Col>
            </Row>
          
        </Container>
    );
});

export default DevicePage;

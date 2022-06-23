import React, { useContext } from 'react';
import { Context } from "../index";
import { createBasket } from "../http/deviceAPI";
import  DeviceItem  from "../components/DeviceItem";
import { Button, Card, Col, Container, Image, Row } from "react-bootstrap";
import { observer } from "mobx-react-lite";

const Basket = observer(() => {
    const { device, user } = useContext(Context)
    const newBacket = {
        user: user.users,
        product: device.backet
    }
    const addProduct = async () => {
        const productBacket = new FormData()
        productBacket.append("user", JSON.stringify(user))
        productBacket.append("product", JSON.stringify(device.backet))
        try {
            await createBasket(newBacket)
        }
        catch (e) {
            console.log(e.messages.error)
        }
    }



    return (
        <div>
            {device.backet.map(product =>
                <DeviceItem key={product.device.id} device={device} />
            )}
            <Button onClick={addProduct}>"Купить"</Button>
        </div>
    );
  
});

export default Basket;

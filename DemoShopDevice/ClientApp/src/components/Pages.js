import React, {useContext, useEffect, useState} from 'react';
import {observer} from "mobx-react-lite";
import {Context} from "../index";
import Pagination from '@mui/material/Pagination';
import Stack from '@mui/material/Stack';

const Pages = observer(() => {
    const {device} = useContext(Context)
    const pageCount = Math.ceil(device.totalCount / device.limit)


    const handleChange = (event, value) => {

        device.setPage(value);

    };
    return (
        <Stack spacing={2}>
            <Pagination
                count={pageCount} page={device.page} onChange={handleChange}
                variant="outlined" color="primary"
            />
        </Stack>
    )

});

export default Pages;
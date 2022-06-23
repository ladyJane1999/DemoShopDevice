import {$authHost, $host} from "./index";

export const createType = async (type) => {
    const { data } = await $authHost.post('typeDevices', type)
    return data
}

export const fetchTypes = async () => {
    const { data } = await $host.get('typeDevices')
    return data
}

export const createBrand = async (brand) => {
    const {data} = await $authHost.post('brands', brand)
    return data
}

export const fetchBrands = async () => {
    const { data } = await $host.get('brands', )
    return data
}

export const createDevice = async (device) => {
    const { data } = await $authHost.post('device', device
    )
    return data
}

export const createBasket = async (basket) => {
    const { data } = await $authHost.post('users/product', basket)
    return data
}

export const fetchDevices = async (typeId, brandId, page, limit= 5) => {
    const { data } = await $host.get('device', {params: {
            typeId, brandId, page, limit
        }})
    return data
}

export const fetchOneDevice = async (id) => {
    const { data } = await $host.get('device' + "/"+ id)
    return data
}

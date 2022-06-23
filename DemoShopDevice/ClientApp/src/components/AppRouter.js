
import { Route, Routes} from "react-router";
import {
    DOCTOR_ROUTE,
    MEDICAL_ROUTE,
    PATIENT_ROUTE,
    REGISTRATION_ROUTE,
    SPECIALITY_ROUTE,
    TIMETABLE_ROUTE
} from "../utils/consts";
import {observer} from "mobx-react-lite";
import MedicalCenter from "../pages/MedicalCenter";
import SpetialityPage from "../pages/SpetialityPage";
import TimeTable from "../pages/TimeTable";
import MainPage from "../pages/MainPage";
import PatientPage from "../pages/PatientPage";
import Registration from "../pages/Registration";
import PageDoctor from "../pages/PageDoctor";


const AppRouter = observer(()=> {

    return (
        <Routes>
            <Route path={SPECIALITY_ROUTE} element= {<SpetialityPage/>} />
            <Route path={MEDICAL_ROUTE} element= {<MainPage/>} />
            <Route path={DOCTOR_ROUTE} element= {<MedicalCenter/>} />
            <Route path={MEDICAL_ROUTE + "/doctor/:id"} element= {<PageDoctor/>} />
            <Route path={TIMETABLE_ROUTE} element= {<TimeTable/>} />
            <Route path={PATIENT_ROUTE} element= {<PatientPage/>} />
            <Route path={REGISTRATION_ROUTE} element= {<Registration/>} />
        </Routes>
    )
});

export default AppRouter;
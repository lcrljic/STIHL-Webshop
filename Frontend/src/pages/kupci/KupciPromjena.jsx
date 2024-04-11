import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { Link, useNavigate, useParams } from "react-router-dom";
import { RoutesNames } from "../../constants";
import KupacService from "../../services/KupacService";
import { useEffect, useState } from "react";


export default function KupciPromjena(){
    const navigate = useNavigate();
    const routeParams = useParams();
    const [kupac, setKupac] = useState({});

   async function dohvatiKupca(){
        const o = await KupacService.getBySifra(routeParams.sifra);
        if(o.greska){
            console.log(o.poruka);
            alert('pogledaj konzolu');
            return;
        }
        setKupac(o.poruka);
   }

   async function promjeni(kupac){
    const odgovor = await KupacService.put(routeParams.sifra,kupac);
    if (odgovor.greska){
        console.log(odgovor.poruka);
        alert('Pogledaj konzolu');
        return;
    }
    navigate(RoutesNames.KUPAC_PREGLED);
}

   useEffect(()=>{
    dohvatiKupca();
   },[]);

    function obradiSubmit(e){ // e predstavlja event
        e.preventDefault();
        //alert('Dodajem kupca');

        const podaci = new FormData(e.target);

        const kupac = {
            ime: podaci.get('ime'),
            prezime: podaci.get('prezime'), 
            mjesto: podaci.get('mjesto'),
            ulicaIBroj: podaci.get('ulicaIBroj'),
            brojMobitela: podaci.get('brojMobitela')          
        };
        //console.log(routeParams.sifra);
        //console.log(kupac);
        promjeni(kupac);

    }

    return (

        <Container>
            <Form onSubmit={obradiSubmit}>

                <Form.Group controlId="ime">
                    <Form.Label>Ime</Form.Label>
                    <Form.Control 
                    type="text" 
                    name="ime" 
                    defaultValue={kupac.ime}
                    required />
                </Form.Group>

                <Form.Group controlId="prezime">
                    <Form.Label>Prezime</Form.Label>
                    <Form.Control 
                    type="text" 
                    name="prezime" 
                    defaultValue={kupac.prezime}
                    required />
                </Form.Group>

                <Form.Group controlId="mjesto">
                    <Form.Label>Mjesto</Form.Label>
                    <Form.Control 
                    type="text" 
                    name="mjesto" 
                    defaultValue={kupac.mjesto}
                    required />
                </Form.Group>

                <Form.Group controlId="ulicaIBroj">
                    <Form.Label>Ulica i broj</Form.Label>
                    <Form.Control 
                    type="text" 
                    name="ulicaIBroj" 
                    defaultValue={kupac.ulicaIBroj}
                    required />
                </Form.Group>

                <Form.Group controlId="brojMobitela">
                    <Form.Label>Broj mobitela</Form.Label>
                    <Form.Control 
                    type="text" 
                    name="brojMobitela" 
                    defaultValue={kupac.brojMobitela}
                    required />
                </Form.Group>

                <hr />
                <Row>
                    <Col>
                        <Link className="btn btn-danger siroko" to={RoutesNames.KUPAC_PREGLED}>
                            Odustani
                        </Link>
                    </Col>
                    <Col>
                        <Button className="siroko" variant="primary" type="submit">
                            Promjeni
                        </Button>
                    </Col>
                </Row>

            </Form>
        </Container>

    );
}
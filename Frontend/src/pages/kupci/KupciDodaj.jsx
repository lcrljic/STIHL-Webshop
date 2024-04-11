import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";
import KupacService from "../../services/KupacService";


export default function KupciDodaj(){
    const navigate = useNavigate();

    async function dodaj(kupac){
        const odgovor = await KupacService.post(kupac);
        if (odgovor.greska){
            console.log(odgovor.poruka);
            alert('Pogledaj konzolu');
            return;
        }
        navigate(RoutesNames.KUPAC_PREGLED);
    }

    function obradiSubmit(e){ // e predstavlja event
        e.preventDefault();
        //alert('Dodajem kupca');

        const podaci = new FormData(e.target);

        const kupac = {
            ime: podaci.get('ime'),  // 'naziv' je name atribut u Form.Control
            prezime: podaci.get('prezime'), //na backend je int
            mjesto: podaci.get('mjesto'),
            ulicaIBroj: podaci.get('ulicaIBroj'),
            brojMobitela: podaci.get('brojMobitela')          
        };

        //console.log(kupac);
        dodaj(kupac);

    }

    return (

        <Container>
            <Form onSubmit={obradiSubmit}>

                <Form.Group controlId="ime">
                    <Form.Label>Ime</Form.Label>
                    <Form.Control type="text" name="ime" required />
                </Form.Group>

                <Form.Group controlId="prezime">
                    <Form.Label>Prezime</Form.Label>
                    <Form.Control type="text" name="prezime" required />
                </Form.Group>

                <Form.Group controlId="mjesto">
                    <Form.Label>Mjesto</Form.Label>
                    <Form.Control type="text" name="mjesto" required />
                </Form.Group>

                <Form.Group controlId="ulicaIBroj">
                    <Form.Label>Ulica i broj</Form.Label>
                    <Form.Control type="text" name="ulicaIBroj" required />
                </Form.Group>

                <Form.Group controlId="brojMobitela">
                    <Form.Label>Broj mobitela</Form.Label>
                    <Form.Control type="text" name="brojMobitela" required />
                </Form.Group>

                <hr />
                <Row>
                    <Col xs={6} sm={6} md={3} lg={6} xl={1} xxl={2}>
                        <Link className="btn btn-danger siroko" to={RoutesNames.KUPAC_PREGLED}>
                            Odustani
                        </Link>
                    </Col>
                    <Col xs={6} sm={6} md={9} lg={6} xl={1} xxl={10}>
                        <Button className="siroko" variant="primary" type="submit">
                            Dodaj
                        </Button>
                    </Col>
                </Row>

            </Form>
        </Container>

    );
}
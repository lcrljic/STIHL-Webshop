import { useEffect, useState } from 'react';
import Container from 'react-bootstrap/Container';
import KupacService from '../../services/KupacService';
import { Button, Table } from 'react-bootstrap';
import { Link, useNavigate } from 'react-router-dom';
import {RoutesNames} from '../../constants'


export default function Kupci(){
    const [kupci, setKupci] = useState();
    const navigate = useNavigate();


    async function dohvatiKupce(){
        await KupacService.get()
        .then((odg)=>{
            setKupci(odg);
        })
        .catch((e)=>{
            console.log(e);
        });
    }

    useEffect(()=>{
        dohvatiKupce();
    },[]);

    async function obrisiAsync(sifra){
        const odgovor = await KupacService._delete(sifra);
        if (odgovor.greska){
            console.log(odgovor.poruka);
            alert('Pogledaj konzolu');
            return;
        }
        dohvatiKupce();
    }

    function obrisi(sifra){
        obrisiAsync(sifra);
    }

    return(
        <>
           <Container>
            <Link to={RoutesNames.KUPAC_NOVI} className='btn btn-success siroko'> Dodaj </Link>
            <Table striped bordered hover responsive>
                    <thead>
                        <tr>
                            <th>Ime</th>
                            <th>Prezime</th>
                            <th>Mjesto</th>
                            <th>Ulica i broj</th>
                            <th>Broj mobitela</th>
                        </tr>
                    </thead>
                    <tbody>
                        {kupci && kupci.map((kupac,index)=>(
                            <tr key={index}>
                                <td>{kupac.ime}</td>
                                <td>{kupac.prezime}</td>
                                <td>{kupac.mjesto}</td>
                                <td>{kupac.ulicaIBroj}</td>
                                <td>{kupac.brojMobitela}</td>
                                <td>
                                    <Button 
                                    onClick={()=>obrisi(kupac.sifra)}
                                    variant='danger'
                                    >
                                        Obriši
                                    </Button>
                                        {/* kosi jednostruki navodnici `` su AltGR (desni) + 7 */}
                                    <Button 
                                    onClick={()=>{navigate(`/kupci/${kupac.sifra}`)}} 
                                    >
                                        Promjeni
                                    </Button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
            </Table>
           </Container>
        </>
    );
}
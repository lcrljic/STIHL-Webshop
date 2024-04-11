import {HttpService} from "./HttpService"

const ime = '/Kupac'

async function get(){
    return await HttpService.get(ime)
    .then((odgovor)=>{
        //console.table(odgovor.data);
        return odgovor.data;
    })
    .catch((e)=>{
        //console.log(e);
        return e;
    })
}

async function post(kupac){
    return await HttpService.post(ime,kupac)
    .then((odgovor)=>{
        //console.table(odgovor.data);
        return {greska: false, poruka: odgovor.data};
    })
    .catch((e)=>{
        //console.log(e);
        return {greska: true, poruka: e};
    })
}

async function put(sifra,kupac){
    return await HttpService.put(ime + '/'+sifra,kupac)
    .then((odgovor)=>{
        //console.table(odgovor.data);
        return {greska: false, poruka: odgovor.data};
    })
    .catch((e)=>{
        //console.log(e);
        return {greska: true, poruka: e};
    })
}

async function _delete(sifraKupca){
    return await HttpService.delete(ime + '/'+sifraKupca)
    .then((odgovor)=>{
        //console.table(odgovor.data);
        return {greska: false, poruka: odgovor.data.poruka};
    })
    .catch((e)=>{
        //console.log(e);
        return {greska: true, poruka: e};
    })
}

async function getBySifra(sifra){
    return await HttpService.get(ime+'/'+sifra)
    .then((o)=>{
        return {greska: false, poruka: o.data}
    })
    .catch((e)=>{
        return {greska: true, poruka: e}
    });
}


export default{
    get,
    post,
    _delete,
    getBySifra,
    put
}
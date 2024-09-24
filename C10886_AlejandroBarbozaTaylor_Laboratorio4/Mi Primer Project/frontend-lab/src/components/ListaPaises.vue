<template>
    <div class="container mt-5">
        <h1 class="display-4 text-center">Lista de Países</h1>
        <div class="row justify-content-end">
            <div class="col-2">
                <a href="/Pais">
                    <button type="button" class="btn
                    btn-outline-secondary float-right">
                    Agregar país
                    </button>
                </a>
            </div>
        </div>
        <table
        class="table is-bordered is-striped is-narrow is-hoverable
        is-fullwidth"
        >
            
            <thead>
                <tr>
                    <th>Nombre</th>
                    <th>Continente</th>
                    <th>Idioma</th>
                    <th>Acciones</th>
                </tr>
            </thead>

            <tbody>
                <tr v-for="(Pais, index) in Paises" :key = "index">
                    <td> {{Pais.nombre}}</td>
                    <td> {{Pais.continente}}</td>
                    <td> {{Pais.idioma}}</td>
                    <td>
                        <button class="btn btn-secondary btn-sm" @click="editarPais(index)">Editar</button>
                        <button class="btn btn-danger btn-sm" @click="eliminarPais(index)">Eliminar</button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>



<script>
import axios from "axios";
export default {
    name: "ListaPaises",
    
    data() {
        return {
            Paises: [
                { nombre: "Costa Rica", continente: "América", Idioma: "Español" },
                { nombre: "Japón", continente: "Asia", Idioma: "Japonés" },
                { nombre: "Corea del Sur", continente: "Asia", Idioma: "Coreano" },
                { nombre: "Italia", continente: "Europa", Idioma: "Italiano" },
                { nombre: "Alemania", continente: "Europa", Idioma: "Alemán" },
            ],
        };
    
    },
    methods: {
        eliminarPais(index) {
            this.Paises.splice(index, 1);
        },
        obtenerTareas() {
            axios.get("https://localhost:7280/api/Pais", {timeout: 5000}).then(
            (response) => {
                this.Paises = response.data;
            });
        },
    },
    created: function () {
        this.obtenerTareas();
    },
};
</script>

<style lang="scss" scoped>

</style>
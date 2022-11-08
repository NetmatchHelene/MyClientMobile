<template>
    <div class="activityList">
        <h1>Lat :             {{this.location.coords.latitude}} Long :             {{this.location.coords.longitude}}</h1>
        <div v-if="errorStr">
            Sorry, but the following error
            occurred: {{errorStr}}
        </div>
        <div v-if="loading">
            zzzz
        </div>
        <div v-else>
            <table class="table table-striped table-bordered">
                <tbody>
                    <tr v-for="(activity) in activities" :key="activity.id">
                        <td>
                            <b>{{activity.activityName}}</b> <br />
                            &euro;{{activity.price}},- p.p.
                        </td>
                        <td><input type="button" value="Meer informatie"/></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script>
import axios from "axios";

    export default {
        name: 'activityList',
        data() {
            return {      
                activities: [],
                location: null,
                loading: false,
                errorStr: null,
                SearchCriteria: {
                    latitude: 0,
                    longitude: 0,
                    distance: 0,
                    price: 0
                }
            }
        },
        beforeCreate () {
            this.loading = true;
            fetch('https://localhost:49153/WeatherForecast')
                .then(response => { console.log(response) });
            let config = {
                headers: {
                    'Content-Type': 'application/json',
                    'accept' : '*/*'
                }
            }
            let data = JSON.stringify({
                latitude: 0,
                longitude: 0,
                distance: 0,
                price: 0
            })
            axios
                .post('https://localhost:49153/api/Activity/getActivities', 
                    data, config)
                .then(response => {
                    this.activities = response.data
                    console.log(response)
                    console.log(this.activities)
                }
            )
                .finally(() => this.loading = false)

            if (!("geolocation" in navigator)) {
                this.errorStr = 'Geolocation is not available.';
                return;
            }

            this.loading = true;
            // get position
            navigator.geolocation.getCurrentPosition(pos => {
                this.loading = false;
                this.location = pos;
                console.log(this.location)
            }, err => {
                this.loading = false;
                this.errorStr = err.message;
                console.log(this.location)
            })

        }
    }

    </script>

<style lang="css">
    @import '../../node_modules/bootstrap/dist/css/bootstrap.min.css'
</style>
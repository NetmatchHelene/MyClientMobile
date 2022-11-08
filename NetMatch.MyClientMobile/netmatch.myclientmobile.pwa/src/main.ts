import { createApp } from 'vue'
import App from './App.vue'
import './registerServiceWorker'
import Camera from "simple-vue-camera";
import router from './router'
import BootstrapVue from 'bootstrap-vue';
import Vue from 'vue';

createApp(App).use(router).component("camera", Camera).mount("#app");
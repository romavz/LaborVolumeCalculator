import Vue from 'vue';
import Nir from './components/nir/nir';
import VueRouter from 'vue-router';

 Vue.use(VueRouter);

let root = new Vue({
    el: '#root',
    router: new VueRouter({ mode: 'history' }),
    render: h => h(require('./components/nir/nir.vue.html'))
});
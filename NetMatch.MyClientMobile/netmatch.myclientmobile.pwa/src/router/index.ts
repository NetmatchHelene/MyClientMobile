import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import Profile from '../views/ProfileView.vue'
import ActivityListView from '../views/ActivityListView.vue'
import ComplaintView from '../views/ComplaintView.vue'

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'home',
    component: HomeView
    },
    {
        path: '/activity',
        name: 'activity',
        component: ActivityListView
    },
    {
        path: '/complaint',
        name: 'complaint',
        component: ComplaintView
    },
    {
        path: '/profile/:username',
        name: 'profile',
        component: Profile,
    },
  {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router

<template>
    <div>
        <div  v-for="(task,index) in tasks" v-bind:key="index" >
                <img src="http://lazi.vn/files/large/5a64450874df215" alt="" width="53">
                <div >
                {{task.content}}
                  <div class="btn-group">
                    <button type="button" class="btn btn-danger" @click="deleteTask(task.id)" >Delete</button>

                </div>
                </div>
              
        </div>
    </div>
</template>

<script>
import {mapGetters} from 'vuex'
import * as constants  from '../constants'

export default {
    name: "ListTask",
    methods: {
        deleteTask(id){
            this.$store.dispatch(constants.ACTION_DELETE_TASK,id)
        }
    },
    computed: {
        tasks(){
            return this.$store.getters.CompleteTasks;
        } 
    },
}
</script>

<style scoped>

</style>
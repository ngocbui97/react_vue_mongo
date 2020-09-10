<template>
    <div>
        <div  v-for="(task,index) in tasks" v-bind:key="index" >
                <img src="http://lazi.vn/files/large/5a64450874df215" alt="" width="53">
                <div v-if="!task.isEditing">
                {{task.content}}
                  <div class="btn-group">
                    <button type="button" class="btn btn-primary" @click="beginEdit(task.id)">Edit</button>
                    <button type="button" class="btn btn-danger" >Complete</button>

                </div>
                </div>
                <div v-else>
                    <input type="text" v-model="task.content" >
                    <button type="button" class="btn btn-primary" @click="editTask(task)" >OK</button>
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
        beginEdit(id){
            console.log(id);
            this.$store.dispatch(constants.ACTION_BEGIN_EDIT,id)
        },
        editTask(task){
            this.$store.dispatch(constants.ACTION_EDIT_TASK,task)
        }
    },
    computed: {
        tasks(){
            console.log(JSON.stringify(this.$store.getters.tasks))
            return this.$store.getters.tasks;
        } 
    },
}
</script>

<style scoped>

</style>
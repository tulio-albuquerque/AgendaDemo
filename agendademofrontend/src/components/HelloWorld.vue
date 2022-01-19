<template>
  <div>
    <main>
      <section class="cards">
        <header>
          <h2 class="label">Lista de contatos</h2>
          <button id="button-add" @click="open('add')">
            <font-awesome-icon class="toggle" icon="plus"></font-awesome-icon>
          </button>
        </header>
        <div v-bind="lazy" v-for="contact in contacts" :key="contact.id">
          <Contact :contact="contact" @open="open"></Contact>
        </div>
      </section>
    </main>
    <AddContact @close="close"></AddContact>
    <EditContact @close="close" :contact="contact">
      <div class="card__content--body">
        <div class="form-control">
          <label for="name">Nome</label>
          <input type="text" v-model="contact.name" id="name" />
          <i class="fas fa-check-circle"></i>
          <i class="fas fa-exclamation-circle"></i>
          <small>Error message</small>
        </div>
        <div class="form-control">
          <label for="phone">Telefone</label>
          <input type="tel" v-model="contact.phone" id="phone" />
          <i class="fas fa-check-circle"></i>
          <i class="fas fa-exclamation-circle"></i>
          <small>Error message</small>
        </div>
        <div class="form-control">
          <label for="email">E-Mail</label>
          <input type="email" v-model="contact.email" id="email" />
          <i class="fas fa-check-circle"></i>
          <i class="fas fa-exclamation-circle"></i>
          <small>Error message</small>
        </div>
      </div>
    </EditContact>
    <DeleteContact @close="close" :contact="contact"></DeleteContact>
  </div>
</template>

<script>
import axios from "axios";
import Contact from "./Contact.vue";
import AddContact from "./AddContact.vue";
import EditContact from "./EditContact.vue";
import DeleteContact from "./DeleteContact.vue";

export default {
  name: "HelloWorld",
  data() {
    return {
      lazy: true,
      contact: {
        id: "",
        name: "",
        phone: "",
        email: "",
      },
      contacts: [],
    };
  },
  mounted() {
    this.update();
  },
  methods: {
    open(modal, contact) {
      this.contact = contact;
      let m = document.getElementById(modal);
      if (!m.classList.contains("modal-open")) {
        m.classList.add("modal-open");
      }
    },
    close(modal) {
      let m = document.getElementById(modal);
      m.classList.remove("modal-open");
      this.update();
    },
    update() {
      axios.get("/contacts").then((response) => {
        this.contacts = response.data
        this.lazy = !this.lazy
      })
    }
  },
  components: {
    Contact,
    AddContact,
    EditContact,
    DeleteContact,
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
main {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  gap: 40px;
  padding: 60px 0;
}

/* cards */

.cards {
  grid-column: 2;
}

.cards > header {
  margin: 10px;
  display: flex;
  justify-content: space-between;
}

/* label */

.label {
  align-self: center;
}

/* botão add */

#button-add {
  border: none;
  border-radius: 50%;
  background-color: #efefef;
  width: 50px;
  height: 50px;
}

#button-add:hover {
  background: #c0c2ce;
}
</style>

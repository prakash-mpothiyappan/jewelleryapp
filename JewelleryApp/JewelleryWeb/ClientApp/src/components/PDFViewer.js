import React from 'react';
import { Page, Text, View, Document, StyleSheet } from '@react-pdf/renderer';

const styles = StyleSheet.create({

  page: {
    flexDirection: 'row',
    backgroundColor: 'white'
  },
  section: {
    margin: 20,
    padding: 10,
    flexGrow: 3
  },
  header: {
    margin:10,
    fontSize:30
  }
});

export const MyDocument = (props) => (
 
  <Document>
   <Page size="A4" style={styles.page}>
      <View style={styles.header}>
         <Text>Jewellery Details:</Text>
      </View>
      <View style={styles.section}>
        <Text>Gold Price(gm) :{props.Values.goldPrice}</Text>
        <Text>Weight(gm) :{props.Values.weight}</Text>{
          props.IsAuthrozied &&<Text>Discount(%) :{ props.Values.discount}</Text>
        }
        <Text>Total Price :{ props.totalPrice}</Text>
      </View>
    </Page>
</Document>
);